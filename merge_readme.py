import os

with open('README.md', 'w') as outfile:    
    table_of_contents = []
    contents = []
    # merge readme
    for files in os.listdir("./"):
        if os.path.isdir(files):
            pwd = files
            for ff in os.listdir(pwd):
                readme = pwd + "/" + ff
                if ff == "README.md":
                    with open(readme) as infile:
                        for line in infile:
                            contents.append(line)
                        
                        infile.seek(0)
                        first_line = infile.readline().rstrip()
                        table_of_contents.append(first_line)
                        contents.append("\n\n\n")
    
    # 목차 생성
    outfile.seek(0)
    outfile.write("# 목차 \n\n")
    
    for readme_head in table_of_contents:
        head = readme_head[2:]
        anchor = readme_head[2:].replace(" ", "-")
        outfile.write(f"- [{head}](#{anchor}) \n")

    outfile.write("\n\n")
    for content in contents:
        outfile.write(content)
